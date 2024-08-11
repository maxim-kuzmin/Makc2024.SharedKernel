import { app } from './Infrastructure/App/indexContext';
import { dummyItem } from './Infrastructure/DummyItem/indexContext';
import { localization } from './Shared/indexContext';

const indexContext = {
  app: {
    ...app,
    localization,
  },
  dummyItem,
};

export default indexContext;