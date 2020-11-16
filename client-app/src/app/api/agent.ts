import axios, { AxiosResponse } from 'axios';
import IProbe from '../models/Probe';

axios.defaults.baseURL = "http://localhost:5000"

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody)
};

const Probes = {
  launch: (highland: string, probes: IProbe[]): Promise<any> => {
  
    const probeBody = {
      "highland": highland,
      "probe": probes,
    }
    const response = requests.post("/probe", probeBody);

    return response;
  } 
};

export default Probes;