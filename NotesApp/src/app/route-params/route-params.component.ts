import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';

@Component({
  selector: 'app-route-params',
  templateUrl: './route-params.component.html',
  styleUrls: ['./route-params.component.scss']
})
export class RouteParamsComponent implements OnInit {

  id:string;

  constructor(private _router:Router, private _activatedRoute:ActivatedRoute) {

   }

  ngOnInit(): void {

    this._activatedRoute.params.subscribe((params: ParamMap) => {
      this.id = params['id'];

    });

    console.log(this.id);

  }

}
