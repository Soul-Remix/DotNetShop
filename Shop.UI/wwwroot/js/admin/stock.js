new Vue({
    el: '#app',
    data: {
        products: [],
        selectedProduct: null,
        newStock: {
            productId: 0,
            qty: 0
        }
    },
    mounted() {
        this.getStock();
    },
    methods: {
        getStock() {
            this.loading = true;
            axios.get('/admin/products')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        updateStock() {
            this.loading = true;
            axios.put('/admin/stocks', {
                stock: this.selectedProduct.stock.map(x => {
                    return {
                        id: x.id,
                        qty: x.qty,
                        productId: this.selectedProduct.id
                    };
                })
            })
                .then(res => {
                    console.log(res);
                    this.selectedProduct.stock.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        deleteStock(id, index) {
            this.loading = true;
            axios.delete('/admin/stocks/' + id)
                .then(res => {
                    console.log(res);
                    this.selectedProduct.stock.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        addStock() {
            this.loading = true;
            axios.post('/admin/stocks', this.newStock)
                .then(res => {
                    console.log(res);
                    this.selectedProduct.stock.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        selectProduct(product) {
            this.selectedProduct = product;
            this.newStock.productId = product.id;
        }
    }
})