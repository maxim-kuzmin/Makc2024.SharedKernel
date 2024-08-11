import modules from '@/lib/modules';

export const { GET, POST } = modules.app.authentication.getNextAuth().handlers;
