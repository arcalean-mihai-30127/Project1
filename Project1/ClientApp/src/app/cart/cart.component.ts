import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Account } from '../models/account';
import { Cart } from '../models/cart';
import { CartItems } from '../models/cart-items';
import { Product } from '../models/product';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  productUrl = 'http://localhost:38169/api/ProductsVal';
  cartUrl = 'http://localhost:38169/api/CartItems';
  userUrl = 'http://localhost:38169/api/user'
  products: Array<CartItems> = [];
  user: Account=new Account();
  userId: string;

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
      this.user.email = localStorage.getItem('token');
      this.getUserId();
      this.httpClient.post(this.cartUrl+"/getItems",this.user).subscribe((response: Array<CartItems>) => {
      this.products = response;
    })
  }

  onRemove(id: number) {
    this.httpClient.delete(this.cartUrl + '?productid=' + id + "&userid=" + this.userId).subscribe((response) => {
      alert("Removed");
      this.refreshCart();
    })
  }

  refreshCart() {
    this.httpClient.post(this.cartUrl+"/getItems",this.user).subscribe((response: Array<CartItems>) => {
      this.products = response;
    })
  } 

  getUserId(){
    this.httpClient.post(this.userUrl+"/getId", this.user).subscribe(res => {
      this.userId = res.toString();
    })
  }
}


