import _buttons from './_buttons/en';
import create from './create/en';

const dummyItem = {
  ..._buttons,
  ...create,
} as const;

export default dummyItem;