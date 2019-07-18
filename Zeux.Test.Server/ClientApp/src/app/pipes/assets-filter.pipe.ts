import { PipeTransform, Pipe, Injectable } from '@angular/core';
import { Asset } from '../models/asset.model';

@Pipe({
  name: 'assetsFilter'
})
@Injectable({ providedIn: 'root' })
export class AssetsFilterPipe implements PipeTransform {

  transform(assets: Array<Asset>, type: string): any {
    if (!assets) {
      return assets;
    }

    return assets.filter(x => type.toLowerCase() === "all" || x.type.name.toLowerCase() === type.toLowerCase());
  }
}
