import _buttons from './_buttons/ru';
import _createForm from './_create-form/ru';

const dummyItem = {
  ..._buttons,
  ..._createForm,
} as const;

export default dummyItem;