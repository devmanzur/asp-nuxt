<template>
  <div class="max-w-sm rounded overflow-hidden shadow-lg mb-3">
    <img
      class="w-full object-cover h-48"
      :src="product.imageUri"
      alt="Product image"
    />
    <div class="px-6 py-4">
      <div class="font-bold text-xl mb-2">{{ product.name }}</div>
      <p class="text-gray-700 text-base">
        {{ product.description }}
      </p>
    </div>
    <div class="px-6 pt-4 pb-2">
      <span
        class="
          inline-block
          bg-gray-200
          rounded-full
          px-3
          py-1
          text-sm
          font-semibold
          text-gray-700
          mr-2
          mb-2
        "
        >${{ product.price }}</span
      >
      <button
        class="
          px-4
          py-1
          my-2
          text-sm text-blue-600
          font-semibold
          rounded-full
          border border-blue-200
          hover:text-white hover:bg-blue-600 hover:border-transparent
        "
        @click="$emit('add-to-cart')"
      >
        Add to cart
      </button>
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
  methods: {},
};
</script>

<style>
</style>