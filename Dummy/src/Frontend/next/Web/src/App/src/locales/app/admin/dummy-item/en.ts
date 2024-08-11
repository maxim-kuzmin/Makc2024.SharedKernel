import _page from './_page/en';
import create from './create/en';

const dummyItem = {
  ..._page,
  ...create,
} as const;

export default dummyItem;