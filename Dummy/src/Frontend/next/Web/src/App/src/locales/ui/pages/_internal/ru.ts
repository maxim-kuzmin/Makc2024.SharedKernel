import _navLinks from './_nav-links/ru';
import _sidenav from './_sidenav/ru';

const _internal = {
  ..._navLinks,
  ..._sidenav,
} as const;

export default _internal;