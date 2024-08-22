import _layout from './_layout/en';
import _page from './_page/en';
import dummyItem from './dummy-item/en';

const app = {
  ..._layout,
  ..._page,
  ...dummyItem,
} as const;

export default app;