import _buttons from './_buttons/ru';
import _table from './_table/ru';
import create from './create/ru';
import edit from './edit/ru';

const dummyItem = {
  ..._buttons,
  ..._table,
  ...create,
  ...edit,
} as const;

export default dummyItem;