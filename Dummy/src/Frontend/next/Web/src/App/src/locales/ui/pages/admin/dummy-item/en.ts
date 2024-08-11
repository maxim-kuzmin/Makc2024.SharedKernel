import _buttons from './_buttons/en';
import _createForm from './_create-form/en';

const dummyItem = {
  ..._buttons,
  ..._createForm,
} as const;

export default dummyItem;

