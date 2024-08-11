import app from './app/en';
import lib from './lib/en';
import ui from './ui/en';

export default {
  ...app,
  ...lib,
  ...ui,
} as const;

