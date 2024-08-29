import _page from './_page/ru';
import create from './create/ru';
import edit from './edit/ru';

const dummyItem = {
  ..._page,
  ...create,
  ...edit,
} as const;

export default dummyItem;