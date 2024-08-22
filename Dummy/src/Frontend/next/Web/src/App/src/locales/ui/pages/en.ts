import _internal from './_internal/en';
import dummyItem from './dummy-item/en';
import login from './login/en';

const pages = {
  ..._internal,
  ...dummyItem,
  ...login,
} as const;

export default pages;