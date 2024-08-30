import domainModel from './DomainModel/indexContext';
import infrastructure from './Infrastructure/indexContext';
import shared from './Shared/indexContext';

const indexContext = {
  app: {
    ...domainModel.app,
    ...infrastructure.app,
    localization :{
      ...shared.localization,
    }
  },
  dummyItem: {
    ...domainModel.dummyItem,
    ...infrastructure.dummyItem,
  },
};

export default indexContext;