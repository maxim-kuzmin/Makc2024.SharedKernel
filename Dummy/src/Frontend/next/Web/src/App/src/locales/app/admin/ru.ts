import _page from './_page/ru';
import dummyItem from './dummy-item/ru';

const admin = {
  ..._page,
  ...dummyItem,
} as const;

export default admin;