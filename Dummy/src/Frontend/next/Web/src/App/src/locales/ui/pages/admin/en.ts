import _navLinks from './_nav-links/en';
import _sidenav from './_sidenav/en';
import dummyItem from './dummy-item/en';

const admin = {
  ..._navLinks,
  ..._sidenav,
  ...dummyItem,
} as const;

export default admin;

