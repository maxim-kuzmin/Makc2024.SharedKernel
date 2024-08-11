import { api } from './Api/serverContext';
import { authentication } from './Authentication/serverContext';
import { localization } from './Localization/serverContext';

export const app = {
  api,
  authentication,
  localization,
};