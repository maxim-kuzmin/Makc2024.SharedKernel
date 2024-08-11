import {
  createAppApiModule,
  createAppConfigOptions,
  createAppConfigOptionsApi,
  createAppConfigOptionsAuthor,
  createAppConfigOptionsLocalization,
  createAppModule,
  createDummyItemModule,
  createHttpModule
} from '@/lib';

const languagesEnv = process.env.NEXT_PUBLIC_APP_CONFIG_LOCALIZATION_LANGUAGES ?? '';

if (!languagesEnv) {
  throw new Error('Languages are not configured');
}

const languages = languagesEnv.split(',');

const defaultLanguage = process.env.NEXT_PUBLIC_APP_CONFIG_LOCALIZATION_DEFAULT_LANGUAGE ?? languages[0];

const appConfigOptions = createAppConfigOptions({
  api: createAppConfigOptionsApi({
    url: process.env.NEXT_PUBLIC_APP_CONFIG_API_URL
  }),
  author: createAppConfigOptionsAuthor({
    url: process.env.NEXT_PUBLIC_APP_CONFIG_AUTHOR_URL
  }),
  localization: createAppConfigOptionsLocalization({
    defaultLanguage,
    languages
  }),
});

const getAppConfigOptions = () => appConfigOptions;

const http = createHttpModule();

const api = createAppApiModule({
  getAppConfigOptionsApi: () => getAppConfigOptions().api,
  getHttpClient: http.getClient
});

const app = createAppModule({
  getAppConfigOptions,
  getAppApiClient: api.getClient
});

const dummyItem = createDummyItemModule({
 getAppApiClient: api.getClient
});

const modules = {
  app,
  dummyItem,
};

export default modules;