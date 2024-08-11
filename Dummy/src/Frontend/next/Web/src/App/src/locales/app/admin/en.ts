import _page from './_page/en';
import dummyItem from './dummy-item/en';

const admin = {
  ..._page,
  ...dummyItem,
} as const;

export default admin;