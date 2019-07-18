import { AssetType } from './asset-type.model';

export class Asset {
  constructor(
    public id: number,
    public name: string,
    public percent: number,
    public sum: number,
    public type: AssetType,
    public assetTypeName: string) { }
}
