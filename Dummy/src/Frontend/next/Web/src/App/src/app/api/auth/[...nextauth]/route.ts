import serverContext from '@/lib/serverContext';

const { handlers } = serverContext.authorization.getNextAuth();

export const { GET, POST } = handlers;
