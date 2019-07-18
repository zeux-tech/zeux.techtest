import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AssetType } from '../models/asset-type.model';
import { Observable } from 'rxjs';
import { Asset } from '../models/asset.model';

@Injectable({ providedIn: 'root' })
export class AssetService {

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  public GetTypes(): Observable<Array<AssetType>> {
    return this.http.get<Array<AssetType>>('/api/assets/types', this.httpOptions);
  }

  public Get(type: string = null): Observable<Array<Asset>> {
    return this.http.get<Array<Asset>>(`/api/assets/?type=${type ? type : ''}`, this.httpOptions);
  }
}
