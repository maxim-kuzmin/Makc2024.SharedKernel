const app = {
  getHrefToDummyItem: () => '/dummy-item',
  getHrefToDummyItemCreate: () => '/dummy-item/create',
  getHrefToDummyItemEdit: (id: number) => `/dummy-item/${id}/edit`,
  getHrefToLogin: () => '/login',
  getHrefToRoot: () => '/',
};

export default app;