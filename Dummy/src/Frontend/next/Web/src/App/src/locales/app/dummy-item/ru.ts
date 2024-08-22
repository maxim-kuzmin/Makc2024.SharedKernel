import _page from './_page/ru';
import create from './create/ru';

const dummyItem = {
  ..._page,
  ...create,
} as const;

export default dummyItem;