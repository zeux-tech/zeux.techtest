import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { AssetType } from 'src/app/models/asset-type.model';
import { Asset } from 'src/app/models/asset.model';
import { AssetService } from 'src/app/services/asset.service';

@Component({
  selector: 'app-my-assets',
  templateUrl: './my-assets.component.html',
  styleUrls: ['./my-assets.component.scss']
})
export class MyAssetsComponent implements OnInit {

  private type: string;
  private assetTypes: Array<AssetType>;
  private assets: Array<Asset>;

  constructor(private route: ActivatedRoute,
    private assetService: AssetService,
    private router: Router) {

    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.type = this.route.snapshot.params.type;
      }
    });
  }

  ngOnInit() {

    this.assetService.GetTypes().subscribe((dataAssetTypes: Array<AssetType>) => {
        this.assetTypes = dataAssetTypes;
    });

    this.assetService.Get()
      .subscribe((dataAssets: Array<Asset>) => {
        this.assets = dataAssets;
      });
  }
}
