import components from './components/ru';
import pages from './pages/ru';

const ui = {
  ...components,
  ...pages,
} as const;

export default ui;
