ARG APP_ENVIRONMENT
ARG APP_PATH
ARG APP_PORT_HTTP
ARG NODE_ENV

FROM node:18-alpine AS base

# Install dependencies only when needed
FROM base AS deps
ARG APP_PATH
# Check https://github.com/nodejs/docker-node/tree/b4117f9333da4138b03a546ec926ef50a31506c3#nodealpine to understand why libc6-compat might be needed.
RUN apk add --no-cache libc6-compat
WORKDIR $APP_PATH

# Install dependencies based on the preferred package manager
COPY package.json yarn.lock* package-lock.json* pnpm-lock.yaml* ./
RUN \
  if [ -f yarn.lock ]; then yarn --frozen-lockfile; \
  elif [ -f package-lock.json ]; then npm ci; \
  elif [ -f pnpm-lock.yaml ]; then corepack enable pnpm && pnpm i --frozen-lockfile; \
  else echo "Lockfile not found." && exit 1; \
  fi

# Rebuild the source code only when needed
FROM base AS builder
ARG APP_ENVIRONMENT
ARG APP_PATH
ARG NODE_ENV
WORKDIR $APP_PATH
COPY --from=deps $APP_PATH/node_modules ./node_modules
COPY . .
# This will do the trick, use the corresponding env file for each environment.
COPY .env.$APP_ENVIRONMENT.docker .env.$NODE_ENV

# Next.js collects completely anonymous telemetry data about general usage.
# Learn more here: https://nextjs.org/telemetry
# Uncomment the following line in case you want to disable telemetry during the build.
# ENV NEXT_TELEMETRY_DISABLED 1

RUN \
  if [ -f yarn.lock ]; then yarn run build; \
  elif [ -f package-lock.json ]; then npm run build; \
  elif [ -f pnpm-lock.yaml ]; then corepack enable pnpm && pnpm run build; \
  else echo "Lockfile not found." && exit 1; \
  fi

FROM base AS runner
ARG APP_PATH
ARG NODE_ENV
WORKDIR $APP_PATH

ENV NODE_ENV=$NODE_ENV
# Uncomment the following line in case you want to disable telemetry during runtime.
# ENV NEXT_TELEMETRY_DISABLED 1

RUN addgroup -g 1001 -S nodejs
RUN adduser -S nextjs -u 1001

COPY --from=builder $APP_PATH/public ./public

# Set the correct permission for prerender cache
RUN mkdir .next
RUN chown nextjs:nodejs .next

# Automatically leverage output traces to reduce image size
# https://nextjs.org/docs/advanced-features/output-file-tracing
COPY --from=builder --chown=nextjs:nodejs $APP_PATH/.next/standalone ./
COPY --from=builder --chown=nextjs:nodejs $APP_PATH/.next/static ./.next/static

USER nextjs

EXPOSE $APP_PORT_HTTP

ENV PORT $APP_PORT_HTTP

# server.js is created by next build from the standalone output
# https://nextjs.org/docs/pages/api-reference/next-config-js/output
CMD HOSTNAME="0.0.0.0" node server.js
