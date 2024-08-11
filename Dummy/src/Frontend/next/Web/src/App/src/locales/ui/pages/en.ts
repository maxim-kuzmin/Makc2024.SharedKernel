import admin from './admin/en';
import login from './login/en';

const pages = {
  ...admin,
  ...login,
} as const;

export default pages;

