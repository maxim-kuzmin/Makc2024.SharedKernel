import _buttons from './_buttons/ru';
import create from './create/ru';

const dummyItem = {
  ..._buttons,
  ...create,
} as const;

export default dummyItem;