import api from './api/en';
import authentication from './authentication/en';

const app = {
  ...api,
  ...authentication
} as const;

export default app;
