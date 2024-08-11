import app from './app/ru';
import lib from './lib/ru';
import ui from './ui/ru';

export default {
  ...app,
  ...lib,
  ...ui,
} as const;
