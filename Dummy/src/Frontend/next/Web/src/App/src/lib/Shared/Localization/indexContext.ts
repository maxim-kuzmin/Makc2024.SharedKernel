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

export const localization = {
  getMessage,
  isLocalizedPathSame,
  isLocalizedPathStartsWith
};