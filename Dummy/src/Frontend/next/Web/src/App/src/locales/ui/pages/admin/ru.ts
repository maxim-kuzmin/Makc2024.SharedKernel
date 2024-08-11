import _navLinks from './_nav-links/ru';
import _sidenav from './_sidenav/ru';
import dummyItem from './dummy-item/ru';

const admin = {
  ..._navLinks,
  ..._sidenav,
  ...dummyItem,
} as const;

export default admin;
