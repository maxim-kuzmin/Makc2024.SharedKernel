import _layout from './_layout/en';
import _page from './_page/en';
import admin from './admin/en';

const app = {
  ..._layout,
  ..._page,
  ...admin,
} as const;

export default app;