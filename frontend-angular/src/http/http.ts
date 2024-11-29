import Axios, { AxiosRequestConfig } from "axios";
import { environment } from "../environments/environment.development";

export const redditClient = Axios.create({ baseURL: `${environment.apiUrl}/api` });

export const redditInstance = <T>(config: AxiosRequestConfig): Promise<T> => {
  const source = Axios.CancelToken.source();
  const promise = redditClient({ ...config, cancelToken: source.token }).then(({ data }) => data);

  // @ts-ignore
  promise.cancel = () => {
    source.cancel("Query was cancelled");
  };

  return promise;
};
