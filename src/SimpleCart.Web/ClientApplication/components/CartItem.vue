<template>
  <div class="mx-8">
    <div class="flex justify-between items-center mt-6 pt-6">
      <div class="flex items-center">
        <img
          :src="product.productImageUrl"
          class="w-20 object-cover h-20 rounded-full"
        />
        <div class="flex flex-col ml-3">
          <span class="md:text-md font-medium">{{ product.productName }}</span>
          <span class="text-sm font-light text-gray-400"
            >$ {{ product.unitPrice }}</span
          >
        </div>
      </div>
      <div class="flex justify-center items-center">
        <div class="pr-8 flex">
          <button class="font-semibold" @click="decreaseQuantity">-</button>
          <input
            type="text"
            class="
              focus:outline-none
              bg-gray-100
              border
              h-6
              w-8
              rounded
              text-sm
              px-2
              mx-2
            "
            :value="product.quantity"
            @input="onQuantityChanged"
          />
          <button class="font-semibold" @click="increaseQuantity">+</button>
        </div>
        <div class="pr-8">
          <span class="text-xs font-medium">${{ product.totalPrice }}</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    product: {
      type: Object,
      required: true,
    },
  },
  methods: {
    increaseQuantity() {
      const quantity = this.product.quantity + 1;
      this.$store.dispatch('cart/setQuantity', {
        productId: this.product.productId,
        quantity,
      });
    },
    decreaseQuantity() {
      const quantity = this.product.quantity - 1;
      this.$store.dispatch('cart/setQuantity', {
        productId: this.product.productId,
        quantity,
      });
    },
    onQuantityChanged(event) {
      const value = event.target.value === '' ? '0' : event.target.value;
      const quantity = parseInt(value);
      this.$store.dispatch('cart/setQuantity', {
        productId: this.product.productId,
        quantity,
      });
    },
  },
};
</script>

<style>
</style>