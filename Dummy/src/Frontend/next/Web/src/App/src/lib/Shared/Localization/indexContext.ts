function formatDateToLocal(dateStr: string, locale: string) {
  const date = new Date(dateStr);
  const options: Intl.DateTimeFormatOptions = {
    day: 'numeric',
    month: 'short',
    year: 'numeric',
  };
  const formatter = new Intl.DateTimeFormat(locale, options);
  return formatter.format(date);
};

function getMessage(functionToGetValue?: () => string, value?: string): string {
  let result = '';

  if (functionToGetValue) {
    result = functionToGetValue();
  } else if (value) {
    result = value;
  }

  return result;
}

function getPathFromLocalized(localizedPath: string) {
  const shoudBeCut = localizedPath.startsWith('/ru/') || localizedPath.startsWith('/en/');

  return shoudBeCut ? localizedPath.substring(3) : localizedPath;
}

function isLocalizedPathSame(localizedPath: string, pattern: string): boolean {
  return getPathFromLocalized(localizedPath) === pattern;
}

function isLocalizedPathStartsWith(localizedPath: string, pattern: string): boolean {
  return getPathFromLocalized(localizedPath).startsWith(pattern);
}

const localization = {
  formatDateToLocal,
  getMessage,
  isLocalizedPathSame,
  isLocalizedPathStartsWith
};

export default localization;