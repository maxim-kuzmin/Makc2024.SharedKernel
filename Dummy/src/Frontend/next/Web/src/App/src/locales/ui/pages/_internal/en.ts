import _navLinks from './_nav-links/en';
import _sidenav from './_sidenav/en';

const _internal = {
  ..._navLinks,
  ..._sidenav,
} as const;

export default _internal;

