new Vue({
    el: "#app",
    data: {
        isLoading: false,
        isError: false,
        products: [],
        productModel: {
            name: "",
            description: "",
            price: 0.0
        },
        editing: false
    },
    mounted() {
        this.getProducts()
    },
    methods: {
        getProduct: async function (id) {
            try {
                this.isLoading = true;
                this.isError = false;
                const res = await axios.get("/admin/products/" + id);
                let product = res.data;
                this.productModel = {
                    id: product.id,
                    name: product.name,
                    description: product.description,
                    price: product.price
                }
            } catch {
                this.isError = true;
            }
            this.isLoading = false;
        },
        getProducts: async function () {
            try {
                this.isLoading = true;
                this.isError = false;
                const res = await axios.get("/admin/products");
                this.products = res.data;
            } catch {
                this.isError = true;
            }
            this.isLoading = false;
        },
        createProduct: async function () {
            try {
                this.isLoading = true;
                this.isError = false;
                const res = await axios.post("/admin/products", this.productModel);
                this.products.push(res.data);
            } catch {
                this.isError = true;
            }
            this.isLoading = false;
            this.editing = false;
        },
        updateProduct: async function () {
            try {
                this.isLoading = true;
                this.isError = false;
                const res = await axios.put("/admin/products/" + this.productModel.id, this.productModel);
                this.products = this.products.map(p => {
                    if (p.id === this.productModel.id) {
                        return this.productModel
                    } else {
                        return p;
                    }
                });
                this.productModel.id = null;
            } catch {
                this.isError = true;
            }
            this.isLoading = false;
            this.editing = false;
        },
        editProduct: function (id) {
            this.getProduct(id);
            this.editing = true;
        },
        deleteProduct: async function (id) {
            try {
                const res = await axios.delete("/admin/products/" + id);
                this.products = this.products.filter(p => {
                    if (p.id !== id) {
                        return id;
                    }
                });
            } catch {
                this.isError = true;
            }
        },
        newProduct() {
            this.editing = true
            this.productModel = {
                name: "",
                description: "",
                price: 0.0
            };
        },
        cancel() {
            this.editing = false
        }
    }
});