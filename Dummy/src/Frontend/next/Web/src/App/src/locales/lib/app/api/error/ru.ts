const error = {
  'lib.app.api.error.BadRequest': 'Плохой запрос',
  'lib.app.api.error.NotFound': 'Не найдено',
  'lib.app.api.error.InternalServerError': 'Внутренняя ошибка сервера',
  'lib.app.api.error.Unauthorized': 'Неавторизованный запрос',
  'lib.app.api.error.Unknown': 'Неизвестная ошибка',
} as const;

export default error;