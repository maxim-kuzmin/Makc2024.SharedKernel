import components from './components/en';
import pages from './pages/en';

const ui = {
  ...components,
  ...pages,
} as const;

export default ui;

