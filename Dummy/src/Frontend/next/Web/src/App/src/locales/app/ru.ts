import _layout from './_layout/ru';
import _page from './_page/ru';
import admin from './admin/ru';

const app = {
  ..._layout,
  ..._page,
  ...admin,  
} as const;

export default app;