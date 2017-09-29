const _isDev = window.location.port.indexOf('5000') > -1;
const getHost = () => {
  const protocol = window.location.protocol;
  const host = window.location.host;
  return `${protocol}//${host}`;
};
const apiURI = _isDev ? 'http://localhost:5000/api/' : `/api/`;

export const ENV = {
  BASE_URI: getHost(),
  BASE_API: apiURI
};