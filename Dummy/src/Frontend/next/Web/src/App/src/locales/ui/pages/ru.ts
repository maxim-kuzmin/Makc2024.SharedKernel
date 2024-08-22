import _internal from './_internal/ru';
import dummyItem from './dummy-item/ru';
import login from './login/ru';

const pages = {
  ..._internal,
  ...dummyItem,
  ...login,
} as const;

export default pages
