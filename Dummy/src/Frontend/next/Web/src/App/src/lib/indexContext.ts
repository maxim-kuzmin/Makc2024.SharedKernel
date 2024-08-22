import { app as appFromDomainModel } from './DomainModel/indexContext';
import { app as appFromInfrastructure } from './Infrastructure/indexContext';
import { dummyItem } from './Infrastructure/DummyItem/indexContext';
import { localization } from './Shared/indexContext';

const indexContext = {
  app: {
    ...appFromDomainModel,
    ...appFromInfrastructure,
    localization,
  },
  dummyItem,
};

export default indexContext;