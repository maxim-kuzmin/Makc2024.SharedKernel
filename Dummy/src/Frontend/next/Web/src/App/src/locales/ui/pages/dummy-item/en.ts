import _buttons from './_buttons/en';
import _table from './_table/en';
import create from './create/en';
import edit from './edit/en';

const dummyItem = {
  ..._buttons,
  ..._table,
  ...create,
  ...edit,
} as const;

export default dummyItem;