import admin from './admin/ru';
import login from './login/ru';

const pages = {
  ...admin,
  ...login,
} as const;

export default pages;
