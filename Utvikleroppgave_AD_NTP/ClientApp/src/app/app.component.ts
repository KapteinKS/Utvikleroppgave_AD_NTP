import { Component } from '@angular/core';
import { product } from './product';
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Utvikleroppgave Avery Dennison NTP';


  constructor(private _http: HttpClient) {

  }

  ngOnInit() {
    this.getProducts();
  }

  public products: product[] = [];


  getProducts() {
    this._http.get<product[]>("/product")
      .subscribe(data => {
        this.products = data;
        for (let product of this.products) {
          product.deliveryDate = new Date
        }
      },
        error => {
          const el = document.createElement('div');
          el.innerHTML = '<h3> Something went wrong when loading products, this is a static array created client side for demonstration </h3>';
          const box = document.getElementById('alert');
          box?.appendChild(el);
          this.products = [new product("Adhesive", "Kg", 0, false, new Date), new product("Ink", "Liter", 0, false, new Date)];
        },
        () => console.log("Get call finished")
      );
  }



  getTime(prod: product) {
    let time = 1;
    if (prod.name == "Adhesive") {
      if (prod.amount > 10 && prod.amount <= 20) {
        time = 2;
      } else if (prod.amount > 20 && prod.amount <= 100) {
        time = 3;
      }
    } else if (prod.name == "Ink") {
      if (prod.amount > 50 && prod.amount <= 200) {
        time = 3;
      } else if (prod.amount > 200 && prod.amount <= 1000) {
        time = 10;
      }
    }

    if (prod.priority) {
      time--;
    }

    //Assuming minimum 1 day delivery
    if (time < 1) {
      return 1;
    }
    return time;
  }

  calculateDelivery(prod: product) {
    let time = this.getTime(prod);
    let date = new Date();
    while (time > 0) {
      date.setDate(
        date.getDate() + 1
      );
      if (!(date.getDay() == 0 || date.getDay() == 6)) {
        time--;
      }
    }
    prod.deliveryDate = date;
    //console.log(this.deliveryDate.toDateString());
  }
}
