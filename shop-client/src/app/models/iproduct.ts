import {ISizes} from './isizes';

export interface IProduct {
  id: string;
  article: string;
  category: string;
  title: string;
  label: string;
  season?: string;
  gender: boolean;
  photo: string;
  sizesAvailable: ISizes[];
}
