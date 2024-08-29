import _page from './_page/en';
import create from './create/en';
import edit from './edit/en';

const dummyItem = {
  ..._page,
  ...create,
  ...edit,
} as const;

export default dummyItem;