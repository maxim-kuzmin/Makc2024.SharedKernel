import api from './api/ru';
import authentication from './authentication/ru';

const app = {
  ...api,
  ...authentication
} as const;

export default app;