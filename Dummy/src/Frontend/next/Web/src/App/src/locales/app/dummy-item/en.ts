import _error from './_error/en';
import _page from './_page/en';
import create from './create/en';
import edit from './edit/en';

const dummyItem = {
  ..._error,
  ..._page,
  ...create,
  ...edit,
} as const;

export default dummyItem;