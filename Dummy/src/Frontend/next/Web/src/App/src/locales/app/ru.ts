import _layout from './_layout/ru';
import _page from './_page/ru';
import dummyItem from './dummy-item/ru';

const app = {
  ..._layout,
  ..._page,
  ...dummyItem,
} as const;

export default app;